namespace DataProcessingCenter.IndexDB
{
    public interface ITransationData
    {
        /// <summary>
        /// 账户数据
        /// </summary>
        string Address { get; set; }
        string Password { get; set; }
        /// <summary>
        /// 交互数据
        /// </summary>
        string ID { get; set; }
        string IdPhotoData { get; set; }
    }
}
