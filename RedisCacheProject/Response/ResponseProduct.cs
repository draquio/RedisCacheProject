namespace RedisCacheProject.Response
{
    public class ResponseProduct<T>
    {
        public bool status {  get; set; }
        public T? value { get; set; }
        public string msg { get; set; }
    }

    public class ResponseProductList<T> : ResponseProduct<T>
    {
        public int page { get; set; }
        public int pageSize { get; set; }
    }
}
