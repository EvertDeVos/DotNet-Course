﻿using System;

namespace Rmdb.Domain.Dtos.Movies
{
    public class MovieDetailDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public TimeSpan RunTime { get; set; }
        public double Score { get; set; }
        public bool Color { get; set; }
    }
}
