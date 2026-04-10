INSERT INTO Branches (BranchName) VALUES
('Computer Science'),
('Mechanical Engineering'),
('Electronics and Communication');

INSERT INTO Addresses (Street, City) VALUES
('12 MG Road', 'Chennai'),
('45 Anna Nagar', 'Chennai'),
('220 Park Street', 'Bangalore'),
('18 Tech Park', 'Hyderabad'),
('77 College Road', 'Mumbai'),
('55 Gandhi Street', 'Pune');

INSERT INTO Students (StudentName, BranchId, AddressId) VALUES
('Arjun Kumar', 1, 1),
('Sneha Reddy', 1, 2),
('Rahul Singh', 2, 3),
('Meera Iyer', 3, 4);

INSERT INTO Teachers (TeacherName, BranchId, AddressId) VALUES
('Dr. Prakash', 1, 5),
('Ms. Kavya', 1, 6),
('Mr. Dinesh', 2, 3);

INSERT INTO Courses (CourseName) VALUES
('Data Structures'),
('Operating Systems'),
('Thermodynamics'),
('Digital Electronics');

INSERT INTO Subjects (SubjectName) VALUES
('C Programming'),
('Algorithms'),
('Heat Transfer'),
('Microprocessors'),
('Database Systems');