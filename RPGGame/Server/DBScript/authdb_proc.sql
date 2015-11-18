use rpggame_authdb;





/*  sp_login_uuid  */
delimiter ;;
drop procedure if exists sp_auth_register_guest;;
create procedure sp_auth_register_guest
(
    in p_usertoken varchar(128)
)
modifies sql data
begin


declare l_ret int;
declare l_userno int;
declare l_authkey int unsigned;

set l_ret = 0;
set l_userno = 0;
set l_authkey = floor(rand() * 100000);


start transaction;
    if exists(select userno from t_accounts where usertoken=p_usertoken lock in share mode) then
    begin
        set l_ret = 1;
    end;
    else
    begin
        insert into t_accounts(usertoken, userid, passwd, authkey) values(p_usertoken, null, null, l_authkey);
        set l_userno = last_insert_id();
    end;
    end if;
commit;

select l_ret, l_userno, l_authkey;


end;;
delimiter ;
