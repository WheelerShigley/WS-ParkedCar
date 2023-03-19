class ParkedCars {
    //instance variables (parallel arrays)
    List<string> make = new List<string>();
    List<string> model = new List<string>();
    List<string> color = new List<string>();
    List<int> licenseNum = new List<int>();

    List<int> minutes_parked = new List<int>();
    List<ParkingTicket> tickets = new List<ParkingTicket>();

    //constructor
    public ParkedCars() {}

    //getters
    public string[] getCar(int index) {
        //check index validity
        if(make.Count < index || index < 0) { return new string[6] {"","","","","",""}; }

        return new string[6] { make[index], model[index], color[index], licenseNum[index].ToString(), minutes_parked[index].ToString(), tickets[index].getFee().ToString() };
    }

    //setters
    public bool setCar(int index, string make_t, string model_t, string color_t, int licenseNum_t) {
        //check index validity
        if(make.Count < index || index < 0) { return false; }

        make[index] = make_t;
        model[index] = model_t;
        color[index] = color_t;
        licenseNum[index] = licenseNum_t;

        minutes_parked[index] = 0;
        tickets[index] = new ParkingTicket();
        
        return true;
    }

    //other methods
    public void tickMinute() {
        for(int index = 0; index < minutes_parked.Count; index++) {
            if(minutes_parked[index] == 59) { tickets[index].chargeCar(); }
            if(60 <= minutes_parked[index]) { tickets[index].violationFee(); }
            minutes_parked[index]++;
        }
    }

    public void addCar(string make_t, string model_t, string color_t, int licenseNum_t) {
        make.Add(make_t);
        model.Add(model_t);
        color.Add(color_t);
        licenseNum.Add(licenseNum_t);

        minutes_parked.Add(0);
        tickets.Add(new ParkingTicket());
    }

    public bool removeCar(int index) {
        //check index validity
        if(make.Count < index || index < 0) { return false; }

        make.RemoveAt(index);
        model.RemoveAt(index);
        color.RemoveAt(index);
        licenseNum.RemoveAt(index);

        minutes_parked.RemoveAt(index);
        Console.WriteLine(minutes_parked.Capacity);
        tickets.RemoveAt(index);

        return true;
    }

    private void printSeperator(int len0, int len1, int len2, int len3, int len4, int len5, char seperator, char corner) {
        string line = corner.ToString() + ' ';
        for(int tmp = 0; tmp < len0; tmp++) { line += seperator.ToString(); } line += ' '+ corner.ToString() +' ';
        for(int tmp = 0; tmp < len1; tmp++) { line += seperator.ToString(); } line += ' '+ corner.ToString() +' ';
        for(int tmp = 0; tmp < len2; tmp++) { line += seperator.ToString(); } line += ' '+ corner.ToString() +' ';
        for(int tmp = 0; tmp < len3; tmp++) { line += seperator.ToString(); } line += ' '+ corner.ToString() +' ';
        for(int tmp = 0; tmp < len4; tmp++) { line += seperator.ToString(); } line += ' '+ corner.ToString() +' ';
        for(int tmp = 0; tmp < len5; tmp++) { line += seperator.ToString(); } line += ' '+ corner.ToString();
        Console.WriteLine(line);
    }

    public void printCars() {
        if(make.Count == 0) { Console.WriteLine("There are no cars here.\n"); return; }

        //get maximum lengths
        int maximum_make_length = "Make".Length, maximum_model_length = "Model".Length,
        maximum_color_length = "Color".Length, maximum_licenseNum_length = "LicenseNumber".Length,
        maximum_minutesParked_length = "Minutes Parked".Length, maximum_charge_length = "Charge".Length;

        for(int tmp = 0; tmp < make.Count; tmp++) {
            if(maximum_make_length < make[tmp].Length) { maximum_make_length = make[tmp].Length; }
            if(maximum_model_length < model[tmp].Length) { maximum_model_length = model[tmp].Length; }
            if(maximum_color_length < color[tmp].Length) { maximum_color_length = color[tmp].Length; }
            if(maximum_licenseNum_length < licenseNum[tmp].ToString().Length) { maximum_licenseNum_length = licenseNum[tmp].ToString().Length; }

            if(maximum_minutesParked_length < minutes_parked[tmp].ToString().Length) { maximum_minutesParked_length = minutes_parked[tmp].ToString().Length; }
            if(maximum_charge_length < tickets[tmp].getFee().ToString().Length) { maximum_charge_length = tickets[tmp].getFee().ToString().Length; }
        }

        //print header
        printSeperator(maximum_make_length, maximum_model_length, maximum_color_length, maximum_licenseNum_length, maximum_minutesParked_length, maximum_charge_length, '-', '+');
            string line = "| Make";
            for(int tmp = 0; tmp < maximum_make_length-"Make".Length; tmp++) { line += " "; } line += " | Model";
            for(int tmp = 0; tmp < maximum_model_length-"Model".Length; tmp++) { line += " "; } line += " | Color";
            for(int tmp = 0; tmp < maximum_color_length-"Color".Length; tmp++) { line += " "; } line += " | LicenseNumber";
            for(int tmp = 0; tmp < maximum_licenseNum_length-"LiscenseNumber".ToString().Length; tmp++) { line += " "; } line += " | Minutes Parked";
            for(int tmp = 0; tmp < maximum_minutesParked_length-"Minutes Parked".Length; tmp++) { line += " "; } line += " | Charge";
            for(int tmp = 0; tmp < maximum_charge_length-"Charge".Length; tmp++) { line += " "; } line += " |";
            Console.WriteLine(line);

        printSeperator(maximum_make_length, maximum_model_length, maximum_color_length, maximum_licenseNum_length, maximum_minutesParked_length, maximum_charge_length, '-', '+');
        //print body
        for(int tmp0 = 0; tmp0 < model.Count; tmp0++) {
            line = "| " + make[tmp0];
            for(int tmp = 0; tmp < maximum_make_length-make[tmp0].Length; tmp++) { line += " "; } line += " | " + model[tmp0];
            for(int tmp = 0; tmp < maximum_model_length-model[tmp0].Length; tmp++) { line += " "; } line += " | " + color[tmp0];
            for(int tmp = 0; tmp < maximum_color_length-color[tmp0].Length; tmp++) { line += " "; } line += " | " + licenseNum[tmp0].ToString();
            for(int tmp = 0; tmp < maximum_licenseNum_length-licenseNum[tmp0].ToString().Length; tmp++) { line += " "; } line += " | " + minutes_parked[tmp0].ToString();
            for(int tmp = 0; tmp < maximum_minutesParked_length-minutes_parked[tmp0].ToString().Length; tmp++) { line += " "; } line += " | " + tickets[tmp0].getFee().ToString();
            for(int tmp = 0; tmp < maximum_charge_length-tickets[tmp0].getFee().ToString().Length; tmp++) { line += " "; } line += " |";
            Console.WriteLine(line);
        }
        //print footer
        printSeperator(maximum_make_length, maximum_model_length, maximum_color_length, maximum_licenseNum_length, maximum_minutesParked_length, maximum_charge_length, '-', '+');
        Console.WriteLine();
    }

}