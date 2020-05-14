<?php

class User{

    private $ID;
    private $FullName;
    private $Email;
    private $Password;
    private $PhoneNumber;
    private $Role;
    private $Wage;

    function __construct($id, $fullName, $email, $password, $phonenumber, $role, $wage){
        $this->ID = $id;
        $this->FullName = $fullName;
        $this->Email = $email;
        $this->Password = $password;
        $this->PhoneNumber = $phonenumber;
        $this->Role = $role;
        $this->Wage = $wage;
    }

    function get_ID(){
        return $this->ID;
    }

    function get_FullName(){
        return $this->FullName;
    }
    function get_Email(){
        return $this->Email;
    }
    function get_Password(){
        return $this->Password;
    }
    function get_PhoneNumber(){
        return $this->PhoneNumber;
    }
    function get_Role(){
        return $this->Role;
    }
    function get_Wage(){
        return $this->Wage;
    }
}