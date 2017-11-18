using System;
using System.Collections.Generic;
using CMSAPI.Models;
using CMSAPI.Data;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMSAPI.Services
{
    public class DBService : IDBService
    {
        /*private readonly ForumContext _context;

        public DBService(ForumContext context)
        {
            _context = context;
        }

        // Threads
        public IEnumerable<Thread> GetAllThreads()
        {
            return _context.Threads;
        }

        public Thread AddThread(Thread newThread)
        {
            _context.Threads.Add(newThread);
            _context.SaveChanges();
            return newThread;
        }

        public Thread GetThread(int id)
        {
            return _context.Threads.FirstOrDefault(i => i.ID == id);
        }

        public Thread RemoveThread(int id)
        {
            var item = GetThread(id);

            _context.Threads.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Thread EditThread(Thread thread)
        {
            _context.Threads.Update(thread);
            _context.SaveChanges();

            return thread;
        }

        // Posts
        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }

        public Post AddPost(Post newPost)
        {
            _context.Posts.Add(newPost);
            _context.SaveChanges();
            return newPost;
        }

        public Post GetPost(int id)
        {
            return _context.Posts.FirstOrDefault(i => i.ID == id);
        }

        public Post RemovePost(int id)
        {
            var item = GetPost(id);

            _context.Posts.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Post EditPost(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();

            return post;
        }

        // Users
        public IEnumerable<Person> GetAllUsers()
        {
            return _context.People;
        }

        public Person AddUser(Person newUser)
        {
            _context.People.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public Person GetUser(string id)
        {
            return _context.People.FirstOrDefault(i => i.Id == id);
        }

        public Person RemoveUser(string id)
        {
            var item = GetUser(id);

            _context.People.Remove(item);
            _context.SaveChanges();
            return item;
        }

        public Person EditUser(Person user)
        {
            _context.People.Update(user);
            _context.SaveChanges();

            return user;
        }*/

    }
}
