<?php

class User{

    private $ID;
    private $FullName;
    private $Email;
    private $Password;
    private $PhoneNumber;
    private $Role;
    private $HourlyRate;

    function __construct($id, $fullName, $email, $password, $phonenumber, $role, $hourlyRate){
        $this->ID = $id;
        $this->FullName = $fullName;
        $this->Email = $email;
        $this->Password = $password;
        $this->PhoneNumber = $phonenumber;
        $this->Role = $role;
        $this->HourlyRate = $hourlyRate;
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
    function get_HourlyRate(){
        return $this->HourlyRate;
    }
}