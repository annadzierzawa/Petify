export interface Pet {
    name: string,
    description: string,
    speciesId: number,
    dateOfBirth: Date
}

export interface PetDTO extends Pet {
    id: number;
    imageFileStorageId: string;
}

export interface PetItemDTO extends PetDTO {
    speciesName: string;
    age: number;
    isChecked: boolean;
}

export interface AddPetCommand extends Pet {
    image: string;
}

export interface UpdatePetCommand extends AddPetCommand {
    id: string;
}

export enum AdvertisementTypes {
    Adoption = 1,
    CyclicalAssistance = 2,
    OneTimeHelp = 3,
    TemporaryAdoption = 4
}

export enum SpeciesTypeEnum {
    Dog = 1,
    Cat = 2,
    Hamster = 3,
    Horse = 4,
    Fish = 5,
    GuineaPig = 6,
    Pig = 7,
    Meerkat = 8,
    Snake = 9,
    Rabbit = 10,
    Spider = 11,
    Bird = 12
}

export const ALL_SPECIES_ARRAY = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
