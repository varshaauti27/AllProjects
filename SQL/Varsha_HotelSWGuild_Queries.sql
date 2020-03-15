--1) List of reservations that end in July 2023, 
--	including the name of the guest, the room number(s), and the reservation dates.
--	4 Rows
SELECT Reservation.ReservationID,(Guest.FirstName +' '+ Guest.LastName) AS 'Guest Name' ,RoomReservation.RoomNo,Reservation.StartDate,Reservation.EndDate 
FROM Reservation 
JOIN RoomReservation ON RoomReservation.ReservationID = Reservation.ReservationID
JOIN Guest ON Guest.GuestID = Reservation.GuestID
WHERE YEAR(EndDate) = 2023 AND MONTH(EndDate) = 7;


--2) List of all reservations for rooms with a jacuzzi, 
--	displaying the guest's name, the room number, and the dates of the reservation.
--	11 Rows

SELECT Reservation.ReservationID,(Guest.FirstName +' '+ Guest.LastName) AS 'Guest Name',RoomReservation.RoomNo,Reservation.StartDate,Reservation.EndDate 
FROM Reservation 
JOIN RoomReservation ON RoomReservation.ReservationID = Reservation.ReservationID
JOIN Room ON Room.RoomNo = RoomReservation.RoomNo
JOIN RoomAmmenities ON RoomAmmenities.RoomNo = Room.RoomNo
JOIN Guest ON Guest.GuestID = Reservation.GuestID
WHERE RoomAmmenities.AmmenityName = 'Jacuzzi';

--3) All the rooms reserved for a specific guest, 
--	including the guest's name, the room(s) reserved, the starting date of the reservation, and 
--	how many people were included in the reservation. (Choose a guest's name from the existing data.)
--  4 Rows

SELECT Reservation.ReservationID,(Guest.FirstName +' '+ Guest.LastName) AS 'Guest Name',RoomReservation.RoomNo,Reservation.StartDate,Reservation.EndDate 
FROM Reservation 
JOIN RoomReservation ON RoomReservation.ReservationID = Reservation.ReservationID
JOIN Room ON Room.RoomNo = RoomReservation.RoomNo
JOIN Guest ON Guest.GuestID = Reservation.GuestID
WHERE Guest.FirstName like 'Mack' AND Guest.LastName like 'Simmer';

--4) List of rooms, reservation ID, and per-room cost for each reservation. 
--	The results should include all rooms, whether or not there is a reservation associated with the room.
--  26 Rows

SELECT Reservation.ReservationID,Room.RoomNo,Room.BasePrice
FROM Reservation
JOIN RoomReservation ON RoomReservation.ReservationID = Reservation.ReservationID
RIGHT OUTER JOIN Room ON Room.RoomNo = RoomReservation.RoomNo

--5) All the rooms accommodating at least three guests and that are reserved on any date in April 2023.
--	 1 Rows

SELECT Room.RoomNo
FROM Reservation
JOIN RoomReservation ON RoomReservation.ReservationID = Reservation.ReservationID
JOIN Room ON Room.RoomNo = RoomReservation.RoomNo
JOIN RoomType ON RoomType.RoomType = Room.RoomType
WHERE RoomType.MaxOccupancy >= 3 AND (YEAR(Reservation.StartDate) = 2023 AND MONTH(Reservation.StartDate) = 4)
Group by Room.RoomNo;

--6) List of All guest names and the number of reservations per guest, 
--	 sorted starting with the guest with the most reservations and then by the guest's last name.

SELECT Guest.LastName AS 'Name',COUNT(Reservation.ReservationID) As 'No Of Reservations'
FROM Reservation
JOIN Guest ON Guest.GuestID = Reservation.GuestID
Group By Guest.LastName
ORDER BY COUNT(ReservationID) desc,Guest.LastName;


--7) Displays the name, address, and phone number of a guest based on their phone number. 
--	(Choose a phone number from the existing data.)

SELECT (Guest.FirstName +' '+ Guest.LastName) As 'Name',Guest.Address,Guest.Phone
FROM Guest
WHERE Guest.Phone like '(308)494-0198';