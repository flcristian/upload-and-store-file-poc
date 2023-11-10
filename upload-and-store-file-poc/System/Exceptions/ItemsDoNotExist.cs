namespace upload_and_store_file_poc.System.Exceptions;

public class ItemsDoNotExist : Exception
{
    public ItemsDoNotExist(string? message) : base(message)
    {
    }
}