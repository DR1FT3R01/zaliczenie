internal class MovementComponent
{
    private readonly IPositionComponent positionComponent;
    private readonly IInputComponent inputComponent;

    public Point PreviousPosition { get; set; }

    public MovementComponent(IPositionComponent positionComponent, IInputComponent inputComponent)
    {
        PreviousPosition = new Point(positionComponent.GetPosition());
        this.positionComponent = positionComponent;
        this.inputComponent = inputComponent;
    }

    public void Move(Point targetPosition)
    {
        PreviousPosition.X = positionComponent.GetPosition().X;
        PreviousPosition.Y = positionComponent.GetPosition().Y;

        positionComponent.GetPosition().X = targetPosition.X;
        positionComponent.GetPosition().Y = targetPosition.Y;
    }

    public Point GetNextPosition()
    {
        Point nextPosition = new Point(positionComponent.GetPosition());
        Point direction = inputComponent.GetDirection();
        nextPosition.X += direction.X;
        nextPosition.Y += direction.Y;

        return nextPosition;
    }
}