using apbd_cw5_git_s33665.Model;

namespace apbd_cw5_git_s33665;

public static class Data
{
    public static List<Room> Rooms { get; set; } = new();
    public static List<Reservation> Reservations { get; set; } = new();

    static Data()
    {
        Rooms.Add(new Room {Id = 1, Name = "Room 1", BuildingCode = "A", Floor = 1, Capacity = 5, HasProjector = true, IsActive = true});
        Rooms.Add(new Room {Id = 2, Name = "Room 2", BuildingCode = "B", Floor = 1, Capacity = 10, HasProjector = false, IsActive = true});
        Rooms.Add(new Room {Id = 3, Name = "Room 3", BuildingCode = "A", Floor = 2, Capacity = 15, HasProjector = true, IsActive = true});
        Rooms.Add(new Room {Id = 4, Name = "Room 4", BuildingCode = "B", Floor = 2, Capacity = 20, HasProjector = false, IsActive = true});
        Rooms.Add(new Room {Id = 5, Name = "Room 5", BuildingCode = "B", Floor = 3, Capacity = 25, HasProjector = true, IsActive = false});
        
        Reservations.Add(new Reservation { 
            Id = 1, RoomId = 1, OrganizerName = "Henoh", Topic = "Chodzenie z Bogiem 101", 
            Date = new DateOnly(2023, 1, 1), 
            StartTime = new TimeSpan(8, 0, 0), 
            EndTime = new TimeSpan(10, 0, 0), 
            Status = "confirmed" 
        });
        Reservations.Add(new Reservation { 
            Id = 2, RoomId = 2, OrganizerName = "Izajasz", Topic = "Proroctwa wszelkiego rodzaju", 
            Date = new DateOnly(2023, 2, 2), 
            StartTime = new TimeSpan(8, 0, 0), 
            EndTime = new TimeSpan(10, 0, 0), 
            Status = "confirmed" 
        });
        Reservations.Add(new Reservation { 
            Id = 3, RoomId = 3, OrganizerName = "Szymon Piotr", Topic = "Nauka chodzenia po wodzie", 
            Date = new DateOnly(2023, 3, 3), 
            StartTime = new TimeSpan(8, 0, 0), 
            EndTime = new TimeSpan(10, 0, 0), 
            Status = "confirmed" 
        });
        Reservations.Add(new Reservation { 
            Id = 4, RoomId = 1, OrganizerName = "Mojżesz", Topic = "Od Egiptu po ziemię Kanaan", 
            Date = new DateOnly(2023, 4, 4), 
            StartTime = new TimeSpan(8, 0, 0), 
            EndTime = new TimeSpan(10, 0, 0), 
            Status = "Planned" 
        });
        Reservations.Add(new Reservation { 
            Id = 5, RoomId = 2, OrganizerName = "Dawid", Topic = "Jak zarządzać królestewm Izraela", 
            Date = new DateOnly(2023, 5, 5), 
            StartTime = new TimeSpan(8, 0, 0), 
            EndTime = new TimeSpan(10, 0, 0), 
            Status = "Confirmed" 
        });
        Reservations.Add(new Reservation { 
            Id = 6, RoomId = 3, OrganizerName = "Malachiasz", Topic = "Proroctwa mesjanistyczne", 
            Date = new DateOnly(2023, 6, 6), 
            StartTime = new TimeSpan(8, 0, 0), 
            EndTime = new TimeSpan(10, 0, 0), 
            Status = "Cancelled" 
        });
    }

}