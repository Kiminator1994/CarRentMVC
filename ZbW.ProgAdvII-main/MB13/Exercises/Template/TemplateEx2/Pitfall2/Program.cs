namespace Pitfall2 {
    class Program {
        static void Main(string[] args) {
            new Downloader().DownloadAsync().Wait();
        }
    }
}
