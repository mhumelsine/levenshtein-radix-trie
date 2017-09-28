using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevenshteinRadixTrie
{
    public class LevenshteinRadixTrie
    {
        private RadixTrieNode root = new RadixTrieNode();
        //add
        public void Add(string key, object value)
        {
            int index = 0;
            RadixTrieNode parent = this.root;

            while (index < key.Length)
            {
                string token = key.Substring(index, key.Length - index);

                //if there are no child add a new node
                if (parent.Children == null || parent.Children.Count == 0)
                {
                    RadixNodeUtils.AddChild(parent, key, value);
                    return;
                }

                foreach(var child in parent.Children){
                    int prefixLength = this.GetPrefixLength(token, child.Key);

                    ////if common is 0 then add new token
                    //if (prefixLength == 0)
                    //{
                    //    RadixNodeUtils.AddChild(parent, token, value);
                    //    break;
                    //}

                    //if common is same as token length, then make sure node is marked as terminal
                    if (prefixLength == token.Length)
                    {
                        child.Value = value;
                        return;
                    }

                    //see if the key needs to be resized; not always, what if needs to be used
                    if (prefixLength < child.Key.Length)
                    {
                        RadixNodeUtils.SplitParent(child, prefixLength, token, value);
                        return;
                    }
                }
                //no matching prefix
                RadixNodeUtils.AddChild(parent, token, value);
                
            }


            //get longest 
        }

        private int GetPrefixLength(string s1, string s2)
        {
            int index = 0;
            int length = Math.Min(s1.Length, s2.Length);

            while (s1[index] == s2[index] && index < length)
            {
                index++;
            }
            return index;
        }

        //delete

        //search
    }
}
