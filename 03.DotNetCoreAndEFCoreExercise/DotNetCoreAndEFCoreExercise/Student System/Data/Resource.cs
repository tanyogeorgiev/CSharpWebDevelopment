using System;
using System.Collections.Generic;
using System.Text;

namespace StudentSystem.Data
{
    public class Resource
    {
        //id, name, type of resource (video / presentation / document / other), URL
        public int Id { get; set; }
        public string Name { get; set; }
        public ResourceType ResourceType { get; set; }
        public string URL { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public List<License> Licenses { get; set; } = new List<License>();

    }
}
