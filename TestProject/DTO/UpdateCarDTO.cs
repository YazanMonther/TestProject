﻿namespace TestProject.DTO
{
    public class UpdateCarDTO
    {
        public Guid Id { get; set; }
        public string? name { get; set; }
        public int? Model { get; set; }

        public string? description { get; set; }
    }
}
