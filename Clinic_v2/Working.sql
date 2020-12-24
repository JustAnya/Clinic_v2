use CLINIC

select *from DOCTOR;
SELECT *FROM TimeDoctor;
SELECT *FROM [USER];
SELECT *FROM Profile;
select *from [DOCTOR]

insert into Specialty(Name_specialty, About_specialty)
values ('��������','����-����������, ���������� ���������� �� �������� �����������, ������� � ������������ �������� ���������� �������.'),
       ('����������', '��� ����, �������� ������������ ������ �������� �������� ������� ��������� ������������� ����������� � ������������������� ���������.  '),
       ('�������', '������� ����-����������, ���������� ���������� �� �������� ������ �������� �������, �����������, ������������ � ������� ������� ��������. '),
       ('�����������', '��� ����, ������������ ������������ � �������� ����������� ���� � ��������������� ������� - ���, ������� �����. '),
       ('����������', '����-����������, ���������� ���������� �� �����������, ������� � ������������ �������� � ����������� �����, �������� � ������ ������� ������� ��� � ��������-������� �������. '),
       ('���������', '����������, ������� ���������� ������������, �������� � ��������������� ������� ��������. ����������� � ���� ��������� ������� ����������� ������� ������� ������� � ��������� ������� �����. � ������� � ������������ �������� �������� ���������� ���������� ������� ����������� � ������� ������������ ���������, � � ����� ������� � ������ �������� - ����� ����������� � ���� ���������. ');

	   CREATE FULLTEXT INDEX ON DOCTOR(Initial_doc)
	KEY INDEX ID ON (DoctorCatalog) 
	WITH (CHANGE_TRACKING AUTO)
   GO

	   delete from Specialty;
insert into TimeUser (AllTime, Time)
values('8:00 - 14:00','8:00 - 8:30'),
('8:00 - 14:00','8:30 - 9:00'),
('8:00 - 14:00','9:00 - 9:30'),
('8:00 - 14:00','9:30 - 10:00'),
('8:00 - 14:00','10:30 - 11:00'),
('8:00 - 14:00','11:00 - 11:30'),
('8:00 - 14:00','11:30 - 12:00'),
('8:00 - 14:00','12:00 - 12:30'),
('8:00 - 14:00','12:30 - 13:00'),
('8:00 - 14:00','13:00 - 13:30'),
('8:00 - 14:00','13:30 - 14:00'),
('14:00 - 20:00','14:00 - 14:30'),
('14:00 - 20:00','14:30 - 15:00'),
('14:00 - 20:00','15:00 - 15:30'),
('14:00 - 20:00','15:30 - 16:00'),
('14:00 - 20:00','16:00 - 16:30'),
('14:00 - 20:00','16:30 - 17:00'),
('14:00 - 20:00','17:00 - 17:30'),
('14:00 - 20:00','17:30 - 18:00'),
('14:00 - 20:00','18:00 - 18:30'),
('14:00 - 20:00','18:30 - 19:00'),
('14:00 - 20:00','19:00 - 19:30'),
('14:00 - 20:00','19:30 - 20:00');

use CLINIC;
GO







   insert into Spec (Name_specialty, About_specialty)
values ('��������','�������� ����� ������ ������� ������� ���������'),
       ('����������', '���������� - ������� ������������������� ���������. '),
       ('�������', '�� ���� ��� ������� ����� ������ ������� ��� �������'),
       ('�����������', '����������� ���������� �������� ����������� ����'),
       ('����������', '���������� �� ���� ��� ����� ���� ������� ������� ������'),
       ('���������', ' ��������� ���������� �������� ������� ��������');