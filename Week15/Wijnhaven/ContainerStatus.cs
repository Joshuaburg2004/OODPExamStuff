// set the int values for each status manually, to prevent errors. Could also have left MarkedForInspection, UnderReview
// and ApprovedAfterInspection alone
public enum ContainerStatus
{
    Processing = 0,
    MarkedForInspection = 1,
    UnderReview = 2,
    Approved = 9,
    ApprovedAfterInspection = 10
}
