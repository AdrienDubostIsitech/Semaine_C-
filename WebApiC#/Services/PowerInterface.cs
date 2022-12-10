public interface PowerInterface {
    
    PowerDTOResponse AddPower(PowerDTORequest dTORequest); 
    PowerDTOResponse updatePower(PowerDTORequest dTORequest);
    PowerDTOResponse deletePower(PowerDTORequest dTORequest); 
}