﻿namespace renato_movie_store.Context.Model
{
    public class LoginInformation
    {
        public int Id { get; set; }

        public string? CustomerName { get; set; }

        public Guid CustomerId { get; set; }

        public DateTime LoginCreateDate { get; set; }
    }
}
