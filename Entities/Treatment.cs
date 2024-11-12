using System.Text.Json.Serialization;

namespace Hospital.Entities
{
    public class Treatment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string TreatmentDetails { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [JsonIgnore]
        public virtual Patient Patient { get; set; }
        [JsonIgnore]
        public virtual Doctor Doctor { get; set; }
    }
}
