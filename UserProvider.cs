namespace MinimalAPIEx;
public class UserProvider : IUserProvider
{
	public User[] Get()
	{
		return new[] { 
			new User { Id = 1, Name = "John Doe" }, 
			new User { Id = 2, Name = "Jane Doe" } 
		};
	}


}

