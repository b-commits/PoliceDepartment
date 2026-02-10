import { useQuery } from "@tanstack/react-query";
import type { UseQueryResult } from "@tanstack/react-query";
import { getOfficers } from "@/lib/api-client";
import type { PoliceOfficer } from "@/types/officer";

export const OFFICERS_QUERY_KEY: readonly string[] = ["officers"] as const;

export function useOfficers(): UseQueryResult<PoliceOfficer[], Error> {
  return useQuery<PoliceOfficer[], Error>({
    queryKey: OFFICERS_QUERY_KEY,
    queryFn: getOfficers,
  });
}