using C01_MesClasses.Enums;
using C01_MesClasses.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C01_MesClasses.Structs
{
    public struct RoomStruct
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public RoomStatus Status { get; set; }
        public decimal Price { get; set; }

        private static int _count;

        public RoomStruct(int capacity, RoomStatus status, decimal price)
        {
            if (capacity >= 6) throw new TooManyBedsException("Trop de lits dans cette chambre");

            Id = ++_count;
            Capacity = capacity;
            Status = status;
            Price = price;
        }
    }

    public record RoomRecord
    {
        public int Id { get; init; }
        public int Capacity { get; init; }
        public RoomStatus Status { get; init; }
        public decimal Price { get; init; }
    }

    public class Room
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public RoomStatus Status { get; set; }
        public decimal Price { get; set; }

        private static int _count;

        public Room(int capacity, RoomStatus status, decimal price)
        {
            Id = ++_count;
            Capacity = capacity;
            Status = status;
            Price = price;
        }
    }
}
