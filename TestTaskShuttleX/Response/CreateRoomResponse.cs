namespace TestTaskShuttleX.Response
{
    public class CreateRoomResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// id user created chat
        /// </summary>
        public int ChatAdminId { get; set; }
    }
}
