using YoutubeProcorretor.Entities;

namespace YoutubeProcorretor.Services
{
    public interface IVideoService
    {
        Task<List<VideoModel>> GetVideos();
        Task<VideoModel> GetVideo(int? id);
        Task<VideoModel> AddVideo(VideoModel video);
        Task<VideoModel> UpdateVideo(VideoModel video);
        Task<VideoModel> DeleteVideo(int id);
    }
}