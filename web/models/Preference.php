<?php

class Preference{

    private $ID;
    private $Date;
    private $EmployeeID;
    private $Availability;
    private $bookedColor;


    function __construct($id, $date, $employeeId,  $availability){
        $this->ID = $id;
        $this->Date = $date;
        $this->EmployeeID = $employeeId;
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

    function get_EmployeeID(){
        return $this->EmployeeID;
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