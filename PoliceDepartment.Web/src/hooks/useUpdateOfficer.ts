import { useMutation, useQueryClient } from "@tanstack/react-query";
import type { UseMutationResult } from "@tanstack/react-query";
import { updateOfficer } from "@/lib/api-client";
import type { UpdateOfficerRequest } from "@/types/officer";
import { OFFICERS_QUERY_KEY } from "./useOfficers";

interface UpdateOfficerVariables {
  id: string;
  data: UpdateOfficerRequest;
}

export function useUpdateOfficer(): UseMutationResult<
  void,
  Error,
  UpdateOfficerVariables
> {
  const queryClient = useQueryClient();

  return useMutation<void, Error, UpdateOfficerVariables>({
    mutationFn: (variables: UpdateOfficerVariables): Promise<void> =>
      updateOfficer(variables.id, variables.data),
    onSuccess: (): void => {
      void queryClient.invalidateQueries({ queryKey: OFFICERS_QUERY_KEY });
    },
  });
}