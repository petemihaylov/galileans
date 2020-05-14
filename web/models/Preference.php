<?php

class Preference{

    private $ID;
    private $Date;
    private $UserID;
    private $Availability;
    private $bookedColor;


    function __construct($id, $date, $userID,  $availability){
        $this->ID = $id;
        $this->Date = $date;
        $this->UserID = $userID;
        $this->Availability = $availability;
    }

    function get_ID(){
        return $this->ID;
    }

    function get_Booked(){
        return $this->bookedColor;
    }

    function get_Date(){
        return $this->Date;
    }

    function get_UserID(){
        return $this->UserID;
    }


    function get_Availability(){
        return $this->Availability;
    }
    function set_Booked($bool){
        $this->bookedColor = $bool;
    }

    function set_Availability($bool){
        $this->Availability = $bool;
    }
}