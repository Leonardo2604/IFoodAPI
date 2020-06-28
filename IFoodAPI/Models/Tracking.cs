using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFoodAPI.Models
{
    public class Tracking
    {
        [JsonProperty("externalId")]
        public string ExternalId { get; private set; }

        [JsonProperty("orderStatus")]
        public string OrderStatus { get; private set; }

        [JsonProperty("workerName")]
        public string WorkerName { get; private set; }

        [JsonProperty("workerPhone")]
        public string WorkerPhone { get; private set; }

        [JsonProperty("workerPhoto")]
        public string WorkerPhoto { get; private set; }

        [JsonProperty("vehicleType")]
        public string VehicleType { get; private set; }

        [JsonProperty("vehiclePlateNumber")]
        public string VehiclePlateNumber { get; private set; }

        [JsonProperty("logisticCompany")]
        public string LogisticCompany { get; private set; }

        [JsonProperty("latitude")]
        public float Latitude { get; private set; }

        [JsonProperty("longitude")]
        public float Longitude { get; private set; }

        [JsonProperty("eta")]
        public int Eta { get; private set; }

        public Tracking(
            string externalId,
            string orderStatus,
            string workerName,
            string workerPhone,
            string workerPhoto,
            string vehicleType,
            string vehiclePlateNumber,
            string logisticCompany,
            float latitude,
            float longitude,
            int eta)
        {
            ExternalId = externalId;
            OrderStatus = orderStatus;
            WorkerName = workerName;
            WorkerPhone = workerPhone;
            WorkerPhoto = workerPhoto;
            VehicleType = vehicleType;
            VehiclePlateNumber = vehiclePlateNumber;
            LogisticCompany = logisticCompany;
            Latitude = latitude;
            Longitude = longitude;
            Eta = eta;
        }
    }
}
