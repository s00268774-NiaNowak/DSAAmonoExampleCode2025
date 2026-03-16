using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSATrees
{
    public class ConversationTree
    {
        public ConversationNode root;

        public ConversationNode InsertAfter(string phrase, string NextPhrase)
        {
            ConversationNode found = Find(root, phrase);
            if (found != null)
            {
                ConversationNode newNode = new ConversationNode(NextPhrase, null);
                found.children.Add(newNode);
                return newNode;
            }
            return null;
        }

        public ConversationNode? Find(ConversationNode current, string Phrase)
        {
            if (current != null)
            {
                if (current.phrase == Phrase)
                {
                    return current;
                }
                else if (current.children.Count() > 0)
                    foreach (ConversationNode node in current.children)
                    {
                        var found = Find(node, Phrase);
                        if (found != null)
                            return found;
                    }
            }
            return null;
        }

        public ConversationNode computerSays(ConversationNode current)
        {
            if (current.children.Count() > 0)
                // int.Parse(Console.ReadLine())
                return current.children[new Random().Next(current.children.Count())];
            return null;
        }
        public ConversationNode HoldConversation(ConversationNode current)
        {
            if (current != null)
            {
                int i = 0;
                foreach (ConversationNode answer in current.children)
                {
                    Console.WriteLine("Responses {0} {1}", i++, answer.phrase);
                }
                if(current.children.Count() > 0)
                    // int.Parse(Console.ReadLine())
                    return current.children[new Random().Next(current.children.Count())];
            }
            return null;
        }

       
    }
    public class ConversationNode
    {
        public List<ConversationNode> children = new List<ConversationNode>();


        public string phrase;


        public ConversationNode(string Phrase,
                        List<string> childPhrases)
        {
            phrase = Phrase;
            if (childPhrases != null)
            {
                foreach (var p in childPhrases)
                {
                    children.Add(new ConversationNode(p, null));
                }
            }
        }


    }
}
