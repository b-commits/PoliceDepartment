import { z } from "zod";

const BADGE_NUMBER_REGEX: RegExp = /^#-[0-9]{3}-[0-9]{3}-[0-9]{3}$/;
const MIN_BIRTH_YEAR: number = 1950;
const MIN_AGE: number = 18;

export const officerFormSchema = z.object({
  firstName: z
    .string()
    .min(1, "First name is required")
    .max(100, "First name must be 100 characters or fewer"),
  lastName: z
    .string()
    .min(1, "Last name is required")
    .max(100, "Last name must be 100 characters or fewer"),
  badgeNumber: z
    .string()
    .regex(BADGE_NUMBER_REGEX, "Badge number must match format #-XXX-XXX-XXX"),
  birthDate: z
    .string()
    .min(1, "Birth date is required")
    .refine(
      (value: string): boolean => {
        const date: Date = new Date(value);
        return !isNaN(date.getTime());
      },
      { message: "Invalid date" }
    )
    .refine(
      (value: string): boolean => {
        const year: number = new Date(value).getFullYear();
        return year >= MIN_BIRTH_YEAR;
      },
      { message: `Birth year must be ${MIN_BIRTH_YEAR} or later` }
    )
    .refine(
      (value: string): boolean => {
        const birthDate: Date = new Date(value);
        const today: Date = new Date();
        const age: number = today.getFullYear() - birthDate.getFullYear();
        const monthDiff: number = today.getMonth() - birthDate.getMonth();
        const adjustedAge: number =
          monthDiff < 0 ||
          (monthDiff === 0 && today.getDate() < birthDate.getDate())
            ? age - 1
            : age;
        return adjustedAge >= MIN_AGE;
      },
      { message: `Officer must be at least ${MIN_AGE} years old` }
    ),
});

export type OfficerFormData = z.infer<typeof officerFormSchema>;