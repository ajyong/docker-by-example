from django.db import models
from django.utils.translation import ugettext_lazy as _
from django_extensions.db.models import TimeStampedModel


# Create your models here.
class Idea(TimeStampedModel):
    name = models.CharField(_('name'), max_length=80)
    description = models.TextField(_('description'))
    projected_revenue = models.DecimalField(_('projected revenue'), decimal_places=2, max_digits=20)
