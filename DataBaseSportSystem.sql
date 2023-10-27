-- 2.1
CREATE PROCEDURE createAllTables
AS

Begin
create table Systemuser
(
   username varchar(20) primary key,
   password varchar(20)
);


create table Stadium
(
    ID int IDENTITY(1,1) primary key,
   name varchar(20),
   location varchar(20),
   capacity int,
   status bit
);

create table StadiumManager
(
    ID int IDENTITY(1,1) primary key,
   name varchar(20),
   stadium_ID int ,
   FOREIGN KEY(stadium_ID) REFERENCES Stadium(ID) on delete cascade,
    FOREIGN KEY(stadium_ID) REFERENCES Stadium(ID) on update cascade,
   username VARCHAR(20) ,
   FOREIGN KEY(username) REFERENCES SystemUser(username) on DELETE cascade,
   FOREIGN KEY(username) REFERENCES SystemUser(username) on update cascade
);

create table Fan
(
    national_ID varchar(20) primary key,
   name varchar(20),
   birth_date date,
   address varchar(20),
   phone_no int,
   status bit,
   username VARCHAR(20)  ,
    FOREIGN KEY(username) REFERENCES SystemUser(username) on DELETE cascade,
   FOREIGN KEY(username) REFERENCES SystemUser(username) on update cascade
);

create table Club
(
   club_ID int IDENTITY(1,1) primary key,
   name varchar(20),
   location varchar(20),
);

create table ClubRepresentative
(
    ID int IDENTITY(1,1) primary key,
   name varchar(20),
   club_ID int FOREIGN KEY REFERENCES Club(club_ID),
   username VARCHAR(20),
     FOREIGN KEY(username) REFERENCES SystemUser(username) on DELETE cascade,
   FOREIGN KEY(username) REFERENCES SystemUser(username) on update cascade
);

create table SportsAssociationManager
(
    ID int IDENTITY(1,1) primary key,
   name varchar(20),
   username VARCHAR(20) ,
     FOREIGN KEY(username) REFERENCES SystemUser(username) on DELETE cascade,
   FOREIGN KEY(username) REFERENCES SystemUser(username) on update cascade
);
create table SystemAdmin
(
    ID int IDENTITY(1,1) primary key,
   name varchar(20),
   username VARCHAR(20),
     FOREIGN KEY(username) REFERENCES SystemUser(username) on DELETE cascade,
   FOREIGN KEY(username) REFERENCES SystemUser(username) on update cascade
);

create table Match
(
    match_ID int IDENTITY(1,1) primary key,
    start_time datetime,
    end_time datetime,
   host_club_ID int,
    FOREIGN KEY(host_Club_Id) REFERENCES Club(club_ID)on DELETE  cascade,
    FOREIGN KEY(host_Club_Id) REFERENCES Club(club_ID)on update  cascade,
   guest_club_ID int,
    FOREIGN KEY(guest_club_ID) REFERENCES Club(club_ID)on delete no action,
    FOREIGN KEY(guest_club_ID) REFERENCES Club(club_ID)on update no action,
   stadium_ID int
    FOREIGN KEY (stadium_ID)REFERENCES Stadium(ID) on delete cascade,
    FOREIGN KEY (stadium_ID)REFERENCES Stadium(ID) on update cascade
);

create table Ticket
(
    ID int IDENTITY(1,1) primary key,
   status bit,
   match_ID int ,
   FOREIGN KEY(match_ID) REFERENCES Match(match_ID)on delete cascade,
   FOREIGN KEY(match_ID) REFERENCES Match(match_ID)on update cascade
);

create table TicketBuyingTransactions
(
   fan_nationalID varchar(20),
    FOREIGN KEY(fan_nationalID) REFERENCES Fan(national_ID) on delete cascade ,
    FOREIGN KEY(fan_nationalID) REFERENCES Fan(national_ID) on update cascade,
   ticket_ID int,
    FOREIGN KEY(ticket_ID) REFERENCES Ticket(ID)on delete cascade,
    FOREIGN KEY(ticket_ID) REFERENCES Ticket(ID)on update cascade

);




create table HostRequest
(
    ID int IDENTITY(1,1) primary key,
   representative_ID int,
    FOREIGN KEY(representative_ID) REFERENCES ClubRepresentative(ID) on delete cascade,
    FOREIGN KEY(representative_ID) REFERENCES ClubRepresentative(ID) on update cascade,
   manager_ID int,
    FOREIGN KEY(manager_ID) REFERENCES StadiumManager(ID)on delete no action,
    FOREIGN KEY(manager_ID) REFERENCES StadiumManager(ID)on update no action,
   match_ID int ,
   FOREIGN KEY(match_ID) REFERENCES Match(match_ID)on delete cascade,
   FOREIGN KEY(match_ID) REFERENCES Match(match_ID)on update cascade,
   status VARCHAR(20)
   );
end


go
create procedure dropAllTables
as
drop table if exists TicketBuyingTransactions
drop table if exists SportsAssociationManager
drop table if exists systemAdmin
drop table if exists HostRequest
drop table if exists ClubRepresentative
drop table if exists Ticket
drop table if exists Fan
drop table if exists StadiumManager
drop table if exists Match
drop table if exists Stadium
drop table if exists Club
drop table if exists systemuser

go

create PROCEDURE dropAllProceduresFunctionsViews
as
drop VIEW if exists allMatches,allCLubs,allRequests,allStadiums,allAssocManagers,allClubRepresentatives,
allStadiumManagers,allFans,allTickets,clubsWithNoMatches,matchesPerTeam,clubsNeverMatched

drop PROCEDURE if exists createAllTables,dropAllTables,clearAllTables,addAssociationManager,
addNewMatch,deleteMatch,deleteMatchesOnStadium,addClub,addTicket,deleteClub,addStadium,
deleteStadium,blockFan,unblockFan,addRepresentative,addHostRequest,addStadiumManager,
acceptRequest,rejectRequest,addFan,purchaseTicket,updateMatchHost

drop FUNCTION if exists requestsFromClub,matchesRankedByAttendance,matchWithHighestAttendance,clubsNeverPlayed,
availableMatchesToAttend,upcomingMatchesOfClub,allPendingRequests,allUnassignedMatches,
viewAvailableStadiumsOn

GO
--d

create procedure clearAllTables
AS

delete FROM hostrequest
delete FROM ticketbuyingtranscations
delete FROM ticket
delete from match
delete from stadiummanager
delete FROM clubrepresentative
delete FROM club
delete FROM stadium
delete FROM SportsAssociationManager
delete FROM systemadmin
delete FROM fan
delete from systemuser

GO

-- 2.2
GO
CREATE VIEW allAssocManagers AS
SELECT sm.username, s.password, sm.name
FROM SystemUser S inner join SportsAssociationManager SM
on sm.username=s.username
GO

go
CREATE VIEW allClubRepresentatives AS
SELECT s.username, s.password, Cr.name, c.name as clubName
FROM SystemUser S inner join ClubRepresentative cr
on cr.username=s.username inner join club c
on c.club_ID=cr.club_ID

GO
CREATE VIEW allStadiumManagers AS
SELECT sm.username,su.password,sm.name ,s.name as stadiumName
from stadiumManager sm inner join stadium s
on s.ID=sm.stadium_ID inner join SystemUser su
on su.username=sm.username

go
create view allFans
AS
select f.username,s.password,f.name,f.national_ID,f.birth_date,f.[status]
from Fan f inner join systemuser s
on f.username=s.username

go
create view allMatches
as
select c1.name as hostClub,c2.name as guestClub,m.start_time
from club C1 inner join Match m
on c1.club_ID=m.host_club_ID inner join club c2
on c2.club_ID=m.guest_club_ID
go

create view allTickets
AS
select c1.name as hostName,c2.name as guestName,s.name,m.start_time
from ticket t inner join match m
on t.match_ID=m.match_ID inner join club c1
on c1.club_ID=m.host_club_ID inner join club c2
on c2.club_ID=m.guest_club_ID inner join stadium s
on s.ID=m.stadium_ID

GO
create VIEW [allCLubs] AS
select c.name,c.location
from Club c;

go
create VIEW allStadiums AS
SELECT s.name,s.location,s.capacity,s.[status]
FROM Stadium s

GO
create view allRequests AS
SELECT c.username asClubRepresentativeUsername ,sm.username as ManagerName,h.status
from ClubRepresentative c inner join HostRequest h
on c.ID=h.representative_ID inner join StadiumManager sm
on h.manager_ID=sm.ID

go

-- 2.3

--1
go

   create procedure addAssociationManager
      @name varchar(20),
      @username varchar(20),
      @password varchar(20)
AS

if (not exists (select u.username
            from systemuser u
             where u.username=@username))
             begin
insert into SystemUser values (@username,@password)
insert into SportsAssociationManager values (@name,@username)
end
GO


--2

GO
create procedure addNewMatch

   @hostName VARCHAR(20),
   @GuestName VARCHAR(20),
   @startTime datetime ,
   @endTime datetime
AS
declare @hostid int,@guestid int
select @hostid =c.club_ID
from club c
where c.name=@hostName

select @guestid =c.club_ID
from club c
where c.name=@GuestName

insert into match values (@startTime,@endTime,@hostid,@guestid,null)
GO

--3



go
create view clubsWithNoMatches
as
select c1.name
from club c1
where  not exists (select c.name
                  from club c inner join match m
                  on (c.club_ID=m.guest_club_ID
                  or c.club_ID=m.host_club_ID)
              where c1.name=c.name    )


go







--4

-- tickets
create procedure deleteMatch
   @hostName VARCHAR(20),
   @GuestName VARCHAR(20)

AS
declare @hostid int,@guestid int
select @hostid=c1.club_ID , @guestid=c2.club_ID
        from club c1 , club c2
        where @hostName=c1.name and @GuestName=c2.name

delete from [Match] where host_club_ID=@hostid and guest_club_ID=@guestid
GO


GO
--5
GO
create procedure deleteMatchesOnStadium
   @stadiumName varchar(20)
AS
declare @stadiumID int
select @stadiumID=s.ID
from Stadium s inner join match m
on s.ID=m.stadium_ID
delete from [Match] where stadium_ID=@stadiumID and start_time>CURRENT_TIMESTAMP
GO
--6

create PROCEDURE addClub
     @clubname VARCHAR(20),
     @location varchar(20)
as
insert into club values (@clubname,@location)

GO
--7
CREATE PROCEDURE addTicket
       @hostname varchar(20),
       @guestname varchar(20),
       @starttime DATETIME
AS
   declare @matchid int
   select @matchid=m.match_ID
   from club c1 inner join match m
   on c1.club_ID=m.host_club_ID inner join club c2
   on c2.club_ID=m.guest_club_ID
   where c1.name=@hostname and c2.name=@guestname and m.start_time=@starttime

insert into ticket values (1,@matchid)

go
--8
create PROCEDURE deleteClub
        @clubname varchar(20)
AS
delete from club where name=@clubname
delete from match
where exists (select *
              from match m inner join club c
              on (m.guest_club_ID=c.club_ID or m.host_club_ID=c.club_ID)
              where c.name=@clubname
              )


--9
go
create procedure addStadium
@stadiumName varchar(20),@location varchar(20),@capacity int
as
insert into Stadium (name,[location],capacity,[status])values
(@stadiumName,@location,@capacity,1)

--10
go
create procedure deleteStadium
@stadiumName varchar(20)
AS
update [Match]
set stadium_ID=null
from Stadium s inner join [Match] M
on s.ID=m.stadium_ID
where s.name=@stadiumName

delete from Stadium where name=@stadiumName
go
--11
create PROCEDURE blockFan
    @nid int
as
update fan
set [status]=0
where national_ID=@nid
GO
--12
create PROCEDURE unblockFan
    @nid varchar(20)
as
update fan
set [status]=1
where national_ID=@nid
--13
GO
create procedure addRepresentative
    @name varchar(20),
    @clubname varchar(20),
    @username varchar(20),
    @password varchar(20)
AS
declare @club_id int
select @club_id=c.club_ID
from club C
where c.name =@clubname
if (not exists (select u.username
            from systemuser u
             where u.username=@username))
             begin
insert into systemuser values(@username,@password)
insert into ClubRepresentative VALUES
(@name,@club_id,@username)
end
--14
GO
create FUNCTION viewAvailableStadiumsOn
(@date datetime)
returns TABLE
AS
RETURN
(
   select s.name,s.[location],s.capacity
   from stadium s
   where s.[status]=1 and not exists
                     (select s1.name,s1.[location],s1.capacity
                      from Stadium s1 inner join match m
                      on s1.ID=m.stadium_ID
                      where m.start_time!=@date)

)
GO

--15

create PROCEDURE addHostRequest
     @clubname varchar(20),
     @stadiumname varchar(20),
     @starttime DATETIME
AS
  declare @representativeID int,@managerID int,@matchid int
select @managerID=sm.ID
from stadium s inner join StadiumManager SM
on s.ID=sm.stadium_ID
where s.name=@stadiumname

select @matchid=m.match_ID
from club c inner join match m
on c.club_ID=m.host_club_ID inner join ClubRepresentative CR
on cr.club_ID=c.club_ID
where c.name=@clubname and m.start_time=@starttime

select @representativeID=cr.ID
from ClubRepresentative CR inner join club C
on c.club_ID=cr.club_ID
where c.name=@clubname

insert into HostRequest values
(@representativeID,@managerID,@matchid,'unhandled')


GO


--16
GO

create function allUnassignedMatches
(@clubname varchar(20))
returns table
as return
(
   select c2.name,m.start_time
   from match m inner join club C
   on c.club_ID=m.host_club_ID inner join club c2
   on c2.club_ID=m.guest_club_ID
   where c.name =@clubname and m.stadium_ID is null
)
GO

--17
GO
create procedure addStadiumManager
    @name varchar(20),
    @stadiumname varchar(20),
    @username varchar(20),
    @password varchar(20)
AS
declare @stadiumid int
select @stadiumid=s.ID
from stadium s
where s.name =@stadiumname
if (not exists (select u.username
            from systemuser u
             where u.username=@username))
             begin
insert into systemuser values(@username,@password)
insert into StadiumManager values
(@name,@stadiumid,@username)
end

--18
GO

create function allPendingRequests
(@stadiumManagerUsername varchar(20))
returns table
as RETURN
(
   select cr.name as ClubRepresentativeName,c.name as guestClubName,m.start_time
   from HostRequest h inner join ClubRepresentative cr
   on h.representative_ID=cr.ID inner join match m
   on m.match_ID=h.match_ID inner join club C
   on c.club_ID=m.guest_club_ID inner join StadiumManager sm
   on h.manager_ID=sm.ID
   where @stadiumManagerUsername=sm.username and h.[status]='unhandled'
   and m.stadium_ID is  null -- ///// is it right>?????
)

GO
GO
--19
create procedure acceptRequest
	@stadiumManagerUsername varchar(20),
    @hostClubName varchar(20),
    @guestClubName varchar(20),
    @startTime DATETIME
AS
declare @representativeID int,@managerid int,@matchid INT,
@capacity int,@count int,@stadiumID int


 select @matchid=m.match_ID,@managerid=sm.ID,@representativeID=cr.ID,
 @capacity=s.capacity,@stadiumID=sm.ID
from match m inner join club c1
on c1.club_ID=m.host_club_ID inner join club c2
on c2.club_ID=guest_club_ID inner join HostRequest H
on h.match_ID=m.match_ID inner join StadiumManager sm
on sm.ID=h.manager_ID inner join Stadium s
on s.ID=sm.stadium_ID inner join ClubRepresentative cr
on cr.club_ID=c1.club_ID
where c1.name=@hostClubName and c2.name=@guestClubName
 and m.start_time=@startTime and sm.username=@stadiumManagerUsername

update HostRequest
set [status]='accepted'
where representative_ID=@representativeID and manager_ID=@managerid
and match_ID=@matchid

set @count =0


update match
set stadium_ID=@stadiumID
where match_ID=@matchid

while @count<@capacity
BEGIN
INSERT INTO ticket ( status, match_Id) VALUES
(1,@matchid)

set @count =@count+1

END



GO
--20
create procedure rejectRequest
	@stadiumManagerUsername varchar(20),
    @hostClubName varchar(20),
    @guestClubName varchar(20),
    @startTime DATETIME

AS
declare @representativeID int,@managerid int,@matchid INT

select @matchid=m.match_ID,@managerid=sm.ID,@representativeID=cr.ID
from match m inner join club c1
on c1.club_ID=m.host_club_ID inner join club c2
on c2.club_ID=guest_club_ID inner join HostRequest H
on h.match_ID=m.match_ID inner join StadiumManager sm
on sm.ID=h.manager_ID inner join ClubRepresentative cr
on cr.club_ID=c1.club_ID
where c1.name=@hostClubName and c2.name=@guestClubName
 and m.start_time=@startTime and sm.username=@stadiumManagerUsername


update HostRequest
set [status]='rejected'
where representative_ID=@representativeID and manager_ID=@managerid
and match_ID=@matchid


go




--21


GO
create procedure addFan
    @name varchar(20),
    @username varchar(20),
    @password varchar(20),
    @nid varchar (20),
    @birthdate DATETIME,
    @address varchar(20),
    @phone_No INT
AS
if (not exists (select u.username
            from systemuser u
             where u.username=@username))
             begin
insert into systemuser values(@username,@password)
insert into fan values
 (@nid,@name,@birthdate,@address,@phone_No,1,@username)
 end
--22
GO

create function upcomingMatchesOfClub
(@clubname varchar(20))
returns table
AS
return (
   (select distinct c1.name as hostName,c2.name as guestName ,m.start_time,s.name as stadiumName --   lacking c2 name maybe we join
   from Club c1 inner join Match m
   on c1.club_ID=m.host_club_ID
   inner join Stadium s on m.stadium_ID=s.ID
   inner join club c2 on  m.guest_club_ID=c2.club_ID
   where m.start_time> CURRENT_TIMESTAMP and (c1.name=@clubname))
   union
   (
      select distinct c2.name as hostName,c1.name as guestName ,m.start_time,s.name as stadiumName --   lacking c2 name maybe we join
   from Club c1 inner join Match m
   on c1.club_ID= m.guest_club_ID
   inner join Stadium s on m.stadium_ID=s.ID
   inner join club c2 on  m.host_club_ID=c2.club_ID
   where m.start_time> CURRENT_TIMESTAMP and (c1.name=@clubname)
   )


)
--23
GO


create function availableMatchesToAttend
(@date datetime)
returns table
AS
return
(
   -- if exists
   -- (
   select c2.name as hostClubName,c1.name as guestClubName,m.start_time,s.name as hostingStadium
   from match m inner join club c1
   on (c1.club_ID=m.guest_club_ID) inner join club c2
   on (c2.club_ID=m.host_club_ID) inner join Stadium s
   on s.ID=m.stadium_ID inner join Ticket t
   on m.match_ID=t.match_ID
   where m.start_time>CURRENT_TIMESTAMP and t.[status]=1
   )

GO

--24
CREATE PROCEDURE purchaseTicket
   @NID VARCHAR(20),
   @hostingClubName VARCHAR(20),
   @GuestName VARCHAR(20),
   @startTime datetime

AS
declare @ticketID int,@fanstatus bit
   select top 1 @ticketID=t.ID
   from Ticket t inner join match m
   on t.match_ID=m.match_ID inner join club c1
   on c1.club_ID=m.host_club_ID inner join club c2
    on c2.club_ID=m.guest_club_ID
   where c1.name=@hostingClubName and @GuestName=c2.name and
   t.[status]=1

   select @fanstatus=f.[status]
   from fan f where f.national_ID=@NID

   if (@fanstatus =1)
   Begin
   insert into TicketBuyingTransactions values (@NID,@ticketID)

      update  ticket
     set status =0
     where ID=@ticketID
   end

GO


--25
create procedure updateMatchHost
     @hostname VARCHAR(20),
     @guestname varchar(20),
     @startTime datetime
   AS
   update Match
   set host_club_ID = guest_club_ID, guest_club_ID = host_club_ID

   from club c1 inner join match m
   on c1.club_ID=m.host_club_ID inner join club c2
   on c2.club_ID=m.guest_club_ID
   where c1.name=@hostname and c2.name=@guestname and m.start_time=@startTime
go
--26
create view matchesPerTeam
AS
select distinct c.name , count ( c.name) as matchesPlayed
from club c inner join Match m
on (c.club_ID=m.guest_club_ID or c.club_ID=m.host_club_ID)
group by c.name
go
--27
create view clubsNeverMatched
AS
select distinct c1.name as firstClub, c2.name as secondClub
from club c1 , club c2
where c1.name!=c2.name and c1.name>c2.name and not exists (select a.guestClub,a.hostClub
                  from allMatches a
                   where( a.guestClub=c1.name and a.hostClub=c2.name) or (
                          a.guestClub=c2.name and a.hostClub=c1.name
                   ))

GO
--28

create function clubsNeverPlayed
(@clubname varchar(20))
returns TABLE
AS
return
(
 (select c.firstClub
         from clubsNeverMatched c
         where c.secondClub=@clubname)
         union
         (select c.secondClub
         from clubsNeverMatched c
         where c.firstClub=@clubname)
)

GO
--helper
create view soldTickets
as
   select count (t.ID) as numberOfTickets,t.match_ID
   from ticket t
   where t.[status]=0
   group by t.match_ID

GO



go
--29
create function matchWithHighestAttendance
()
returns table
as return
(
   select c1.name as hostClub ,c2.name as guestClub
   from Ticket t inner join Match m
   on t.match_ID=m.match_ID inner join club c1
   on c1.club_ID=m.host_club_ID inner join club c2
   on c2.club_ID=m.guest_club_ID inner join soldTickets st
   on st.match_ID=m.match_ID
   group by c1.name,c2.name
   having max (st.numberOfTickets)=count(t.ID) -- VIP NOT RIGHT MASHY GHALAAAATTTTTT

)


GO

--30
CREATE FUNCTION matchesRankedByAttendance
()
RETURNS table
as return
(
   select c1.name as hostName ,c2.name -- sold ticket club
   from match m inner join soldTickets s
   on s.match_ID=m.match_ID inner join club c1
   on c1.club_id=m.host_club_id inner join club c2
   on c2.club_id=guest_club_id
   order by s.numberOfTickets desc offset 0 row
)

--31
go
create function requestsFromClub
(@stadiumName varchar(20),@clubRepres varchar(20))
RETURNS table
as return
(
   select c2.name as hostClub ,c1.name as guestClub
   from stadium s inner join Match m
   on s.id=m.stadium_ID inner join HostRequest H
   on h.match_ID=m.match_ID inner join ClubRepresentative c
   on h.representative_ID=c.ID inner join club c1
   on c1.club_ID=m.guest_club_ID inner join club c2
   on c2.club_ID=m.host_club_ID
   where @stadiumName=s.name and @clubRepres=c.name
)
GO
