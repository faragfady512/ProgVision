namespace ProgVision.PL.Dtos
{
    public class GetAllCoursesParams
    {

        public string Sort { get; set; }

        public string CourseName { get; set; }

        public string CategoryName { get; set; }
        public int CategroryId { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TranierId { get; set; }



    }
}
