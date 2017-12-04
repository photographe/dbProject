SELECT * FROM TripTable WHERE TripTable.UserId = (SELECT userid FROM users WHERE name = 'Dummy')

select * from users