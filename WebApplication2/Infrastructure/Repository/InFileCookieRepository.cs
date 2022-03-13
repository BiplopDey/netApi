﻿using WebApplication2.Domain.Repository;
using WebApplication2.Domain;

namespace WebApplication2.Infrastructure.Repository
{
    public class InFileCookieRepository : ICookieRepository
    {
        private static List<Cookie> cookies = new List<Cookie>()
        {
            new Cookie(1, "Gingerbread", 3 ),
            new Cookie(2, "Chocolate Chip", 3 ),
            new Cookie(3, "Dinosaurus", 3 ),
            new Cookie(4, "Macaroon", 3 )
        };

        public static void clear()
        {
            cookies = new List<Cookie>();
        }
        public void Save(Cookie cookie)
        {
            if (Exists(cookie.id))
                return;
            
            cookies.Add(cookie);
        }
        public bool Exists(int id)
        {
            return cookies.FindAll(cookie => cookie.id == id).Count != 0;
        }

        public List<Cookie> All()
        {
            return cookies;
        }
    }
}
