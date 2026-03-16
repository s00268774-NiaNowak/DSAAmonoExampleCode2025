using DSATrees;

namespace ConversationConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConversationTree conversation = new ConversationTree();

            conversation.root = new ConversationNode("What is your Name",
                                    new List<string>()
                                                {"None of your Business",
                                                    "My Name is Bill",
                                                    "I've lost my memory"});

            //ConversationNode phrase = conversataion.Find(conversataion.root, "None of your Business");
            conversation.InsertAfter("None of your Business", "How rude");
            conversation.InsertAfter( "How rude","Bye");
            conversation.InsertAfter("My Name is Bill", "Quack Quack");

            ConversationNode current = conversation.root;
            // Assume the computer starts the coversation
            Console.WriteLine("Computer says ------> {0}", current.phrase);
            // Possible User Responses
            while (current.children.Count() > 0)
            {
                Console.WriteLine("Answers:");
                int i = 0;
                foreach (ConversationNode answer in current.children)
                {
                    Console.WriteLine("{0} {1}", i++, answer.phrase);
                }

                Console.WriteLine("Select an answer");
                string? input = Console.ReadLine();
                int selection = Convert.ToInt32(input);
                Console.WriteLine("You said {0}", current.children[selection].phrase);
                // Computer responds to the answer
                current = conversation.computerSays(current.children[selection]);
                // if we are done with the conversation, end it
                if (current == null)
                {
                    Console.WriteLine("Conversation Ended");
                    break;
                }
                else Console.WriteLine("Computer says {0}", current.phrase);

            }
            //int i = 1;

            //foreach (ConversationNode answer in current.children)
            //{
            //    if (answer.children.Count() > 0)
            //    {
            //        int j = 1;
            //        foreach (ConversationNode response in answer.children)
            //        {
            //            Console.WriteLine("Responses {0} {1}", j++, response.phrase);
            //        }
            //    }
            //}
            //ConversationNode n = conversation.HoldConversation(conversation.root);
            
            //Console.WriteLine("Computer says {0}", n.phrase);

            Console.ReadKey();
        }
    }
}
