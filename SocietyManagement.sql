CREATE TABLE TEACHER (
    id INT NOT NULL,
    faculty_name VARCHAR(255) NOT NULL,
    employment_type VARCHAR (255) NOT NULL,
    
    -- CONSTRAINTS
    PRIMARY KEY (id)
);

CREATE TABLE FINANCEDEPARTMENT (
    id INT NOT NULL,
    name varchar(255),
    position varchar(255),
    
    -- CONSTRAINTS
    PRIMARY KEY (id)
);

CREATE TABLE STUDENT (
    id int NOT NULL,
    student_name varchar(255),
    email_id varchar(255),
    -- CONSTRAINTS
    PRIMARY KEY (id)
);

CREATE TABLE SOCIETY (
    id INT NOT NULL, 
    name varchar(255),
    president_id int NOT NULL,
    vice_president_id int NOT NULL ,
    treasurer_id  int NOT NULL,
    gs_id int NOT NULL,
    faculty_head_id INT NOT NULL,
    faculty_cohead_id INT NOT NULL,
    budget_approver_id INT NOT NULL,
    budget INT,
    
--    CONSTRAINTS
    PRIMARY KEY (id),
    FOREIGN KEY (faculty_head_id) REFERENCES TEACHER (id),
    FOREIGN KEY (faculty_cohead_id) REFERENCES TEACHER (id), 
    FOREIGN KEY (budget_approver_id) REFERENCES FINANCEDEPARTMENT(id),   
    FOREIGN KEY (vice_president_id) REFERENCES STUDENT (id),    
    FOREIGN KEY (president_id) REFERENCES STUDENT (id) ,   
    FOREIGN KEY (gs_id) REFERENCES STUDENT (id) ,
    FOREIGN KEY (treasurer_id) REFERENCES STUDENT (id)
);

CREATE TABLE EVENT (
    id INT NOT NULL,
    name varchar(255) NOT NULL,
    society_id int NOT NULL,
    event_type varchar(255) NOT NULL,
    guest_name varchar(255),
    venue varchar(255),
    Date_Time varchar(255),
    
    -- CONSTRAINTS
    PRIMARY KEY (id),
    FOREIGN KEY (society_id) REFERENCES SOCIETY(id) --confirm
);

CREATE TABLE REGISTRATIONS(
    id INT NOT NULL, 
    event_id INT NOT NULL,
    student_id int,
    
    -- CONSTRAINTS
    PRIMARY KEY (id),
    FOREIGN KEY (event_id) REFERENCES EVENT(id),
    FOREIGN KEY (student_id) REFERENCES STUDENT(id)
);

-- INSERTING STUDENTS 
INSERT INTO STUDENT VALUES (191273 , 'Mustafa Bawany' , 'k191273@nu.edu.pk');
INSERT INTO STUDENT VALUES (191475 , 'Ahsan Naqvi' , 'k191273@nu.edu.pk'); 
INSERT INTO STUDENT VALUES (191440 , 'Ajar Sarmad' , 'k191273@nu.edu.pk'); 
INSERT INTO STUDENT VALUES (191255 , 'Sara Sameer' , 'k191273@nu.edu.pk'); 

-- INSERTING TEACHERS
INSERT INTO TEACHER VALUES (0 , 'Murtaza Munawwar' , 'Visiting Faculty');
INSERT INTO TEACHER VALUES (1 , 'Muhammad Shahzad' , 'Permenant Faculty');
INSERT INTO TEACHER VALUES (2 , 'Murtaza Munawwar' , 'Permenant Faculty');
INSERT INTO TEACHER VALUES (3 , 'Sayed Yousuf' , 'Visiting Faculty');

-- INSERTING Finance Personals 
INSERT INTO FINANCEDEPARTMENT VALUES (0 , 'Abdul Saeed' , 'Accounts Manager');
INSERT INTO FINANCEDEPARTMENT VALUES (1 , 'Abdullah Hasan' , 'Finance Head');
INSERT INTO FINANCEDEPARTMENT VALUES (2 , 'Rafay Gul' , 'Cashier');
INSERT INTO FINANCEDEPARTMENT VALUES (3 , 'Anas Jalil' , 'Fee Administrator');


-- ADDING SOCIETIES INFROMATION 
INSERT INTO SOCIETY VALUES (0,'ACM' , 191273, 191440 , 191475, 191255, 0, 1, 1, 500000);

-- ADDING AN EVENT
--INSERT INTO EVENT VALUES (society_id, id, event_name, event_type, guest_name, venue, date&time) 
INSERT INTO EVENT VALUES (0, 'Roadmap to Google' , 0, 'Session', 'Umer Abdullah' , 'Main Auditorium', '2022-12-06 02:00:00');


-- ADDING STUDENT REGISTRATIONS FROM AN EVENT
-- INSERT INTO REGISTRATIONS VALUES (id, event_id, student_id)
INSERT INTO REGISTRATIONS VALUES (0,0, 191273);

-- DROP TABLES
DROP TABLE SOCIETY;
DROP TABLE EVENT;
DROP TABLE STUDENT;
DROP TABLE TEACHER;
DROP TABLE FINANCEDEPARTMENT;


-- Random Queries
SELECT * FROM STUDENT;
SELECT * FROM TEACHER;
SELECT * FROM FINANCEDEPARTMENT;
SELECT * FROM SOCIETY;
SELECT * FROM EVENT;
SELECT * FROM REGISTRATIONS;