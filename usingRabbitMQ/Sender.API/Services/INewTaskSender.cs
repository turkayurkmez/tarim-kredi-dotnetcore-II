namespace Sender.API.Services
{
    public interface INewTaskSender
    {
        Task SendNewTask(string message);
    }


}
