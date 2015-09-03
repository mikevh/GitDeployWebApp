using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace WebJob1
{
    public class Functions
    {
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public static void ProcessQueueMessage([QueueTrigger("queue")] string message, TextWriter log) {
            Console.WriteLine("to console:" + message);
            try {
                var db = new Db();
                db.Messages.Add(new Message {Body = "D " + message, ReceivedOn = DateTime.UtcNow});
                db.SaveChanges();
            }
            catch (Exception e) {
                log.WriteLine("Exception: " + e.Message);
            }
            log.WriteLine("D:" + message);
        }
    }

    public class Db : DbContext
    {
        public Db()
            : base("name=DefaultConnection")
        {
            
        }

        public DbSet<Message> Messages { get; set; }
    }

    public class Message
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime ReceivedOn { get; set; }
    }
 }
