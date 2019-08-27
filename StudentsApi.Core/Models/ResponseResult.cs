namespace StudentsApi.Core.Models
{
	public class ResponseResult
	{
		public bool IsSuccessful { get; set; }
		
		public string Message  { get; set; }

		public ResponseResult(bool isSuccessful)
		{
			this.IsSuccessful = isSuccessful;
		}
		
		public ResponseResult(bool isSuccessful, string message)
		{
			IsSuccessful = isSuccessful;
			Message = message;
		}
	}

}
