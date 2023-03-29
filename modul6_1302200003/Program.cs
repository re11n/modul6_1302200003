// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;

internal class Program
{
    static void Main(String[] args)
    {
        SayaTubeUser test = new SayaTubeUser("David");
        SayaTubeVideo video = new SayaTubeVideo("Avenger 1");
        test.AddVideo(video);
        SayaTubeVideo video1 = new SayaTubeVideo("Avenger 2");
        test.AddVideo(video1);
        SayaTubeVideo video2 = new SayaTubeVideo("Avenger 3");
        test.AddVideo(video2);
        SayaTubeVideo video3 = new SayaTubeVideo("Avenger 4");
        test.AddVideo(video3);
        video3 = new SayaTubeVideo("Avenger 5");
        test.AddVideo(video3);
        video3 = new SayaTubeVideo("Avenger 6");
        test.AddVideo(video3);
        video3 = new SayaTubeVideo("Avenger 7");
        test.AddVideo(video3);
        video3 = new SayaTubeVideo("Avenger 8");
        test.AddVideo(video3);
        video3 = new SayaTubeVideo("Avenger 9");
        test.AddVideo(video3);
        video3 = new SayaTubeVideo("Avenger 10");
        test.AddVideo(video3);
        video3.IncreasePlayCount(50000000);
        video3.PrintVideoDetails();

        test.PrintAllVideoPlaycount();

        SayaTubeUser test1 = new SayaTubeUser(null);
        video3 = new SayaTubeVideo(null);
        test.AddVideo(video3);

    }
}

public class SayaTubeVideo
{
    private int id;
    public String title;
    private int PlayCount;

    public SayaTubeVideo(String judul)
    {
        Contract.Requires(title != null);
        Contract.Requires(title.Length < 200);
        Random ids = new Random();
        this.title = judul;
        id = ids.Next(0, 100000);
        this.PlayCount = 0;
    }

    public int GetVideoPlayCount()
    {
        return this.PlayCount;
    }

    public void IncreasePlayCount(int i)
    {
        try
        {
            if (i >= 25000000) throw new Exception("Melebihi limit angka");
            if (i < 0) throw new Exception("tidak boleh bilangan negatif");
            PlayCount = PlayCount + i;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    public void PrintVideoDetails()
    {
        Console.WriteLine(this.id);
        Console.WriteLine(this.title);
        Console.WriteLine(this.PlayCount);
    }
}

public class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideo;
    private String username;

    public SayaTubeUser(String user)
    {
        Contract.Requires(user != null);
        this.username = user;
        this.uploadedVideo= new List<SayaTubeVideo>();
        Random ids = new Random();
        id = ids.Next(0, 100000);
    }


    public int GetTotalVideoPlayCount()
    {
        int temp = 0;
        foreach (SayaTubeVideo item in uploadedVideo)
        {
            temp = item.GetVideoPlayCount() + temp;
        }
        return temp;
    } 


    public void AddVideo(SayaTubeVideo video)
    {
        Contract.Requires(video != null);
        uploadedVideo.Add(video);
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine("User: " + this.username);
        int temp = 0;
        for(int i = 0; i< uploadedVideo.Count; i++)
        {
            Console.WriteLine("Video " + (i+1) + " Judul = " + uploadedVideo[i].title);
        }
    }
}