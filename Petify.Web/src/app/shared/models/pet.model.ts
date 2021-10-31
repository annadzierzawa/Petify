export interface Pet {
    name: string,
    description: string,
    speciesId: number,
    dateOfBirth: Date
}

export interface PetDTO {
    id: string;
    imageFileStorageId: string;
}

export interface AddPetCommand extends Pet {
    image: string;
}

export interface UpdatePetCommand extends AddPetCommand {
    id: string;
}

