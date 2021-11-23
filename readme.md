# A Domain Driven Design abstractions

## Entities and Aggregates

Entity models an individual this that has a unique identity.

Aggregates model a domain concept made up of one or many related entities.  It represent boundary where all the entities in the relationship must be consistent according to some business rules.  Changes to entities in this relation should be persisted together or the aggregate no longer makes sense. 



## References

<a target="_blank" href="https://www.amazon.com.au/gp/product/0321125215/ref=as_li_tl?ie=UTF8&camp=247&creative=1211&creativeASIN=0321125215&linkCode=as2&tag=yaugohchow-22&linkId=d31be4680001f9c870ebba0db3f20025">Domain-driven Design: Tackling Complexity in the Heart of Software</a>

<a target="_blank" href="https://www.amazon.com.au/gp/product/0321834577/ref=as_li_tl?ie=UTF8&camp=247&creative=1211&creativeASIN=0321834577&linkCode=as2&tag=yaugohchow-22&linkId=7c93106e92a19e1dc48f3797fcbc4855">Implementing Domain-Driven Design</a>

<a target="_blank" href="https://www.amazon.com.au/gp/product/B01JJSGE5S/ref=as_li_tl?ie=UTF8&camp=247&creative=1211&creativeASIN=B01JJSGE5S&linkCode=as2&tag=yaugohchow-22&linkId=3707d9cded081b749784c938d71fbfd6">Domain-Driven Design Distilled</a>