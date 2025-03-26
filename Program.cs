using modul6_103022330044;
using System.Collections.Generic;

namespace modul6_103022330044
{
    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            if (string.IsNullOrEmpty(title) || title.Length > 100)
                throw new ArgumentException("Judul tidak boleh kosong dan maksimal 100 karakter.");

            Random rand = new Random();
            this.id = rand.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }


        public void IncreasePlayCount(int count)
        {
            if (count > 10000000)
                throw new ArgumentOutOfRangeException("Penambahan play count maksimal 10.000.000.");

            checked //biar ga overflow
            {
                this.playCount += count;
            }
        }


        public void PrintVideoDetails()
        {
            Console.WriteLine($"Video ID: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Play Count: {playCount}");
        }

        public int GetPlayCount()
        {
            return this.playCount;
        }

        public string GetTitle()
        {
            return this.title;
        }
    }

    public class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        public string username;

        public SayaTubeUser(string username)
        {
            Random random = new Random();
            this.id = random.Next(10000, 99999);
            this.username = username;
            this.uploadedVideos = [];
        }

        public int GetTotalVideoPlayCount()
        {
            int totalPlayCount = 0;
            foreach (SayaTubeVideo video in uploadedVideos)
            {
                totalPlayCount += video.GetPlayCount();
            }

            return totalPlayCount;
        }

        public void AddVideo(SayaTubeVideo video)
        {
            uploadedVideos.Add(video);
        }

        public void PrintAllVideoPlayCount()
        {
            int i = 0;
            Console.WriteLine($"User: {this.username}");
            foreach (SayaTubeVideo video in uploadedVideos)
            {
                i++;
                Console.WriteLine($"Video {i + 1} judul: " + video.GetTitle());
            }
            
        }
    }
    class Program
    {
        static void Main()
        {
            SayaTubeUser user = new SayaTubeUser("Rakan");
            SayaTubeVideo video1 = new SayaTubeVideo("Review Film Mickey 17 oleh Rakan");
            SayaTubeVideo video2 = new SayaTubeVideo("Review Film Conclave oleh Rakan");
            SayaTubeVideo video3 = new SayaTubeVideo("Review Film The Monkey oleh Rakan");
            SayaTubeVideo video4 = new SayaTubeVideo("Review Film No Other Land oleh Rakan");
            SayaTubeVideo video5 = new SayaTubeVideo("Review Film Anora oleh Rakan");
            SayaTubeVideo video6 = new SayaTubeVideo("Review Film The Brutalist oleh Rakan");
            SayaTubeVideo video7 = new SayaTubeVideo("Review Film Chungking Express oleh Rakan");
            SayaTubeVideo video8 = new SayaTubeVideo("Review Film In The Mood For Love oleh Rakan");
            SayaTubeVideo video9 = new SayaTubeVideo("Review Film Companion oleh Rakan");
            SayaTubeVideo video10 = new SayaTubeVideo("Review Film Gladiator II oleh Rakan");

            try
            {
                video1.IncreasePlayCount(111111);
                video2.IncreasePlayCount(133123);
                video3.IncreasePlayCount(23131);
                video4.IncreasePlayCount(31313);
                video5.IncreasePlayCount(1321);
                video6.IncreasePlayCount(3213);
                video7.IncreasePlayCount(132113);
                video8.IncreasePlayCount(542535);
                video9.IncreasePlayCount(432532);
                video10.IncreasePlayCount(5245223);

                user.AddVideo(video1); user.AddVideo(video2); user.AddVideo(video3); user.AddVideo(video4); user.AddVideo(video5);
                user.AddVideo(video6); user.AddVideo(video7); user.AddVideo(video8); user.AddVideo(video9); user.AddVideo(video10);

                user.PrintAllVideoPlayCount();
                Console.WriteLine($"Total Play Count: {user.GetTotalVideoPlayCount()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}