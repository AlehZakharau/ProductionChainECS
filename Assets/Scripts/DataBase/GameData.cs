using System;
using System.Runtime.Serialization;

namespace DataBase
{
    [Serializable]
    public class GameData : ISerializable
    {
        public ManufactureData[] manufactureData;
        public TransportData[] transportData;
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class ManufactureData
    {
        public int resourceAmount;
        public int level;
        public int[] demandUpgradeResource;
    }

    [Serializable]
    public class TransportData
    {
        public int sender;
        public int receiver;
    }
}