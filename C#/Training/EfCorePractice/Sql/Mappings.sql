INSERT INTO CourseStudent (CoursesCourseId, StudentsStudentId) VALUES
(1, 1),  -- Arjun → DS
(2, 1),  -- Arjun → OS
(1, 2),  -- Sneha → DS
(4, 2),  -- Sneha → Digital Electronics
(3, 3),  -- Rahul → Thermodynamics
(4, 4);  -- Meera → Digital Electronics

INSERT INTO CourseSubject (CoursesCourseId, SubjectsSubjectId) VALUES
(1, 1), -- DS ↔ C Programming
(1, 2), -- DS ↔ Algorithms
(1, 5), -- DS ↔ DBMS

(2, 1), -- OS ↔ C Programming
(2, 5), -- OS ↔ DBMS

(3, 3), -- Thermodynamics ↔ Heat Transfer

(4, 4); -- Digital Electronics ↔ Microprocessors

INSERT INTO SubjectTeacher (SubjectsSubjectId, TeachersTeacherId) VALUES
(1, 1),  -- C Programming → Dr. Prakash
(2, 1),  -- Algorithms → Dr. Prakash

(5, 2),  -- DBMS → Ms. Kavya

(3, 3),  -- Heat Transfer → Mr. Dinesh
(4, 3);  -- Microprocessors → Mr. Dinesh