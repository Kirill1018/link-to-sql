using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args) => new Program().Code();
        void Code()
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            IEnumerable<songs> song_coll = from songs in context.songs orderby songs.date_of_song_addendum_to_the_database select songs;
            List<songs> song_list = song_coll.OrderByDescending(song => song.date_of_song_addendum_to_the_database).ToList();
            foreach (songs song in song_list) Console.WriteLine(song.ToString());
            Console.WriteLine("***");
           
            DateTime past_time = new DateTime();
            past_time = DateTime.Now.AddMonths(-1);
            IEnumerable<songs> old_songs = from songs in context.songs where songs.date_of_song_addendum_to_the_database >= past_time orderby songs.title select songs;
            foreach (songs song in old_songs) Console.WriteLine(song.ToString());
            Console.WriteLine("***");
            
            Console.WriteLine($"{song_list[song_list.Count - 1]} and {song_list[0]}");
        }
    }
}