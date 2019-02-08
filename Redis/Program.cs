using StackExchange.Redis;
using System;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //string connectionString;
            var redis = ConnectionMultiplexer.Connect("localhost");
            var db = redis.GetDatabase();

            db.StringSet("A", 1);
            string a = db.StringGet("A").ToString();
            db.StringGet("A").TryParse(out int aProfessor);
            db.StringIncrement("A");
            db.StringGet("A");
            db.SetAdd("tech", "SQL");
            db.HashSet("cli", "AA", 1);
            db.ListLeftPush("L1", "A");
            db.ListLeftPush("L2", "B");

            //40.77.30.246

            string channel = "Gustavo";
            var sub = redis.GetSubscriber();
            sub.Subscribe(channel, (ch, msg) =>
            {
                //Console.WriteLine(msg.ToString());

                Console.ReadKey();

                string pergunta = Console.ReadLine();
                string numeroPergunta = pergunta.Substring(0, 2);
                string equipe = "OnHelp";
                string resposta = "A pergunta" + numeroPergunta + "possui a resposta: Não sei";

                db.HashSet(numeroPergunta, equipe, resposta);

            
            });

            
            //sub.Subscribe()


        }
    }
}
