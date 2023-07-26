using DotNetServer.Core.Context;
using DotNetServer.Modules.UserModule.Entities;
using DotNetServer.Modules.UserModule.Model.Requests;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Modules.UserModule.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FoodbContext _context;

    public UserRepository(FoodbContext context)
    {
        _context = context;
    }

    public User GetUserById(Guid id)
    {
        return _context.Users.Find(id) ?? throw new InvalidOperationException();
    }

    public int CreateUser(User user)
    {
        _context.Users.Add(user);

        return _context.SaveChanges();
    }

    public int UpdateUser(Guid id, User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        return _context.SaveChanges();
    }

    public void DeleteUser(Guid id)
    {
        var user = _context.Users.Find(id);

        if (user is null) return;
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public User GetUserId(MinimalUserRequest minimalUserRequest)
    {
        var user = _context.Users.FirstOrDefault(user =>
            user.Email == minimalUserRequest.Email && user.Name == minimalUserRequest.Name &&
            user.Password == minimalUserRequest.Password);
        if (user is null) throw new Exception("user not found");

        return user;
    }
}