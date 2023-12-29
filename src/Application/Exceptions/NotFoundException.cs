

namespace Application.Exceptions
{
    public class NotFoundException:Exception
    {
        public NotFoundException():base()
        {
            
        }

        public NotFoundException(string Message):base(Message) 
        {
            
        }

        public NotFoundException(string Message,Exception InnerException) : base(Message, InnerException)
        {

        }

        public NotFoundException(string name, object key) : base($"خطا در سیستم {key}")
        {

        }
    }
}
