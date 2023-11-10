namespace upload_and_store_file_poc.System.Exceptions;

public class ItemDoesNotExist : Exception
{
    public ItemDoesNotExist(string? message) : base(message)
    {
    }
}