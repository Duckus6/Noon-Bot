using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace NoonBot
{
    class Bot
    {
        DiscordClient discord;
        CommandService commands;
        Random rand;
        string[] randomReactions;
        string[] users;
        string[] Delet;
        private User user;

        public Bot()
        {
            rand = new Random();
            Delet = new string[]
            {
                "Reaction/delet.jpg",
                "Images/dlet this.jpg",
                "Images/delet waifu.jpg",
                "Images/delet jotaro.png",
                "Images/jotaro delet.jpg"
            };
            randomReactions = new string[]
            {
                "Reaction/delet.jpg",
                "Reaction/Fetish.jpg",
                "Reaction/Flandre 187.png",
                "Reaction/Flandre stuff.png",
                "Reaction/flandre_scarlet.png",
                "Reaction/HIgh impact sexual cleaning.jpg",
                "Reaction/Hong.png",
                "Reaction/idk.png",
                "Reaction/diejoubu.jpg",
                "Reaction/Aww sheeeeeeet.jpg",
                "Reaction/Incubator.jpg"


            };
            users = new string[]
            {
                "Puck_The_Elf_Dimention_Warrior",
                "a fucking mistake",
                "Phantom",
                "Duckus",
                "Ajojoreference",
                "AlgarothDaMage",
                "Dicks Out for Jotaro",
                "Honin",
                "I want to fuck robots",
                "I need an actual Nickname",
                "JosukeHasNeatHair",
                "Kingtheboss00",
                "Mob",
                "purpurina",
                "SlowMotionWalter",
                "Winger",
                "Zakyoin",
            };
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MjIzMTE0MTA4NzA5NTAyOTc2.CrcSDw.A6T_znbfEzzm-K66BkLpzzRxqUg");
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });
            commands = discord.GetService<CommandService>();
            RegisterImageCommand();
            commands.CreateCommand("dick")
                .Do(async (e) =>
                {
                        int ran = rand.Next(users.Length);
                        string user = users[ran];
                        await e.Channel.SendMessage(user + " wants the D");
                });
            commands.CreateCommand("do you love me")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("ew no you ugly");  
                });
            commands.CreateCommand("phantom")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Phantom's a am beautiful");
                });
            commands.CreateCommand("time")
                .Do(async (e) =>
                {
                    await e.Channel.SendTTSMessage("It's High Noon");
                });
            commands.CreateCommand("honin")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Honin's playlist: http://star-plats.tumblr.com/post/150056426875/i-looked-around-for-a-spotify-playlist-of-most-if");
                });
            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hi!");
                });
            commands.CreateCommand("nutshack")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("https://www.youtube.com/watch?v=0I_OEDuUKYI&feature=youtu.be");
                });
            commands.CreateCommand("read")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("http://pastebin.com/CJPJP2Hi");
                });
            
        }
        private void RegisterImageCommand()
        {
            commands.CreateCommand("Ryuu")
                .Do(async (e) =>
                {
                   await e.Channel.SendFile("Images/RYUU.jpg");
                });
            commands.CreateCommand("random")
                .Do(async (e) =>
                {
                    int ran = rand.Next(randomReactions.Length);
                    string randomimage = randomReactions[ran];
                    await e.Channel.SendFile(randomimage);
                });
            commands.CreateCommand("delet")
                .Do(async (e) =>
                {
                    int ran = rand.Next(Delet.Length);
                    string randdelet = Delet[ran];
                    await e.Channel.SendFile(randdelet);
                });
        }
        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
