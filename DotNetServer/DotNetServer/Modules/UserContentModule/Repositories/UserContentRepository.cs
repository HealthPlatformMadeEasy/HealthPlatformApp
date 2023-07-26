using DotNetServer.Core.Context;
using DotNetServer.Modules.UserContentModule.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Modules.UserContentModule.Repositories;

public class UserContentRepository : IUserContentRepository
{
    private readonly FoodbContext _context;

    public UserContentRepository(FoodbContext context)
    {
        _context = context;
    }

    public UserContent GetUserContentById(Guid id)
    {
        return _context.UserContents.Find(id) ?? throw new InvalidOperationException();
    }

    public int CreateUserContent(UserContent userContent)
    {
        _context.UserContents.Add(userContent);

        return _context.SaveChanges();
    }

    public int UpdateUserContent(Guid id, UserContent userContent)
    {
        _context.Entry(userContent).State = EntityState.Modified;

        return _context.SaveChanges();
    }

    public void DeleteUserContent(Guid id)
    {
        var userContent = _context.UserContents.Find(id);

        if (userContent is null) return;

        _context.UserContents.Remove(userContent);
        _context.SaveChanges();
    }

    public List<UserContent> GetUserContentByUserId(Guid id)
    {
        return _context.UserContents.Where(u => u.UserId == id).ToList();
    }

    public void CreateMultipleUserContent(List<UserContent> userContents)
    {
        _context.UserContents.AddRange(userContents);
        _context.SaveChanges();
    }
}