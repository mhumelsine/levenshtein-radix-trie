using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevenshteinRadixTrie
{
    public class RadixTrieNode
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public ICollection<RadixTrieNode> Children { get; set; }
    }

    public static class RadixNodeUtils
    {
        private static ICollection<RadixTrieNode> CreateChildCollection()
        {
            return new List<RadixTrieNode>();
        }
        private static RadixTrieNode CreateChildNode(string key, object value)
        {
            return new RadixTrieNode
            {
                Key = key,
                Value = value
            };
        }
        public static RadixTrieNode AddChild(RadixTrieNode parent, string key, object value)
        {            
            var childNode = CreateChildNode(key, value);

            AddChild(parent, childNode);

            return childNode;
        }

        public static void AddChild(RadixTrieNode parent, params RadixTrieNode[] children)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }

            if (parent.Children == null)
            {
                parent.Children = CreateChildCollection();
            }

            foreach (var child in children)
            {
                parent.Children.Add(child);
            }
        }

        public static void SplitParent(RadixTrieNode parent, int prefixLength, string key, object value)
        {
            //get the new leaf key
            string newLeafKey = parent.Key.Substring(prefixLength, parent.Key.Length - prefixLength);
            //get the new parent key
            string newParentKey = parent.Key.Substring(0, prefixLength);
            //get the new child key
            string newChildKey = key.Substring(prefixLength, key.Length - prefixLength);

            //create new leaf node
            RadixTrieNode newLeafNode = CreateChildNode(newLeafKey, parent.Value);
            //create new leaf node
            RadixTrieNode newChildNode = CreateChildNode(newChildKey, value);

            //modify parent node (maybe this should be refactored to use immutable object)
            parent.Key = newParentKey;
            parent.Value = null;

            AddChild(parent, newLeafNode, newChildNode);
        }
    }
}
